import { CommonModule, registerLocaleData } from '@angular/common';
import { ChangeDetectionStrategy, Component, model, ViewChild } from '@angular/core';
import localeTr from '@angular/common/locales/tr'; // Türkçe lokalizasyon verisi, Tarihi Türkçe yapmak için
import { FormControl, FormGroup, FormsModule, NgForm, ReactiveFormsModule } from '@angular/forms';
import { MatCalendarCellClassFunction, MatDatepicker, MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { FilteredReservationsModel } from '../../models/reservations-filteres.model';
import { HttpService } from '../../services/http.service';
import { RoomsModel } from '../../models/hotel-rooms.model';
import { MatTabsModule } from '@angular/material/tabs';
import { ReservationsModel } from '../../models/reservations.model';
import { SwalService } from '../../services/swal.service';

registerLocaleData(localeTr, 'tr');  // Tarihi Türkçe yapmak için

@Component({
  selector: 'app-reservations',
  standalone: true,
  imports: [FormsModule,CommonModule, ReactiveFormsModule, MatDatepickerModule, MatFormFieldModule, MatInputModule, MatNativeDateModule, MatIconModule, MatButtonModule, MatCardModule, MatTabsModule],
  templateUrl: './reservations.component.html',
  styleUrl: './reservations.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ReservationsComponent{

  filteredModel: FilteredReservationsModel = new FilteredReservationsModel();
  roomsModel: RoomsModel[] = [];
  totalPrice: number = 0;
  diffDays: number = 0;

  reservationsModel : ReservationsModel = new ReservationsModel();

  showLabel: boolean = false;
  isRoomSelected: boolean = false;
  selectedTabIndex: number = 0;


  dateClass: MatCalendarCellClassFunction<Date> = (cellDate, view) => {
    // Sadece "ay görünümünde" (month view) çalıştırmak için kontrol.
    if (view === 'month') {
      const date = cellDate.getDate();  // Hücre tarihini alır, yani o günün ay içindeki gününü.

      // Ayın 1. ve 20. günlerini vurgulamak için koşul.
      return date === 1 || date === 20 ? 'example-custom-date-class' : '';
    }

    // Eğer "ay görünümünde" değilse, boş döner, yani hiçbir özel stil uygulanmaz.
    return '';
};


  dateForm: FormGroup;
  dateForm2: FormGroup;


  selected = model<Date | null>(null);

  @ViewChild('picker1') datePicker1!: MatDatepicker<Date>;
  @ViewChild('picker2') datePicker2!: MatDatepicker<Date>;


  
  readonly range = new FormGroup({
    start: new FormControl<Date | null>(null),
    end: new FormControl<Date | null>(null),
  });

  tarih: Date = new Date();
  cikisTarihi: Date = new Date();

  constructor(
    private http: HttpService,
    private swal : SwalService
  ) { 
    this.cikisTarihi.setDate(this.tarih.getDate() + 1);

    const today = new Date();
    const ttoday = new Date();

    this.dateForm = new FormGroup({
      selectedDate: new FormControl(today), // Seçilen tarihi yakalamak için
    });

    this.dateForm2 = new FormGroup({
      sselectedDate: new FormControl(ttoday), // Seçilen tarihi yakalamak için
    });
  }

  showTabs() {
    this.showLabel = true;
  }

  onSelectRoom() {
    this.isRoomSelected = true;
    this.selectedTabIndex = 1;
  }
  openDatepicker() {
    this.datePicker1.open();
  }

  openReleaseDatepicker(){
    this.datePicker2.open();
  }


  onDateChange(event: any) {
    this.dateForm.patchValue({ selectedDate: event });

    // Tarih bilgilerini alma
    const selectedDate = new Date(event);
    const year = selectedDate.getFullYear();
    const month = selectedDate.getMonth() + 1;
    const day = selectedDate.getDate();
    const dayName = selectedDate.getUTCDay();

    this.reservationsModel.CheckInDate = this.filteredModel.startDate
  }


  onReleaseDateChange(event: any) {
    this.dateForm2.patchValue({ sselectedDate: event });

    // Tarih bilgilerini alma
    const sselectedDate = new Date(event);
    const syear = sselectedDate.getFullYear(); // Yılı al
    const smonth = sselectedDate.getMonth() + 1; // Ayı al (0-11 arası döner, bu yüzden +1 eklenir)
    const sday = sselectedDate.getDate();
    const sdayName = sselectedDate.getUTCDay();

    this.reservationsModel.CheckOutDate = this.filteredModel.endDate
  }

  filteredRooms(form: NgForm) {
    this.filteredModel.startDate = this.dateForm.get('selectedDate')?.value;
    this.filteredModel.endDate = this.dateForm2.get('sselectedDate')?.value;

    this.http.post<string>("Room/GetAllFilteredRooms", this.filteredModel, (res) => {
        // this.roomsModel = res.data;

        this.roomsModel = this.groupRoomsByName(res.data);
        
    });
}

groupRoomsByName(rooms: any[]): any[] {  // odaları isme göre gruplama işlemi
  const groupedRooms = rooms.reduce((acc, room) => {
      if (!acc[room.roomName]) {
          acc[room.roomName] = room;
      }
      return acc;
  }, {});

  return Object.values(groupedRooms); // Return the values as an array
}

//   hesapla(price: number) {
//     let checkInDate = this.filteredModel.startDate;
//     let checkOutDate = this.filteredModel.endDate;

//     if (!checkInDate) {
//       checkInDate = new Date(); // Bugünün tarihi
//   }
//   if (!checkOutDate) {
//       checkOutDate = new Date(checkInDate);
//       checkOutDate.setDate(checkOutDate.getDate() + 1); // Check-in tarihinin bir gün sonrası
//   }

//     const timeDiff = Math.abs(new Date(checkOutDate).getTime() - new Date(checkInDate).getTime());
//     this.diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24)); // Gün sayısını elde etmek için
//     this.totalPrice = this.diffDays * price;
//     this.reservationsModel.TotalPrice = this.totalPrice;
// }

hesapla(price: number) {
  let checkInDate = this.filteredModel.startDate ? new Date(this.filteredModel.startDate) : new Date(); // Giriş tarihi
  let checkOutDate = this.filteredModel.endDate ? new Date(this.filteredModel.endDate) : null; // Çıkış tarihi

  // Eğer çıkış tarihi girilmemişse, giriş tarihinden bir gün sonrası olarak ayarla
  if (!checkOutDate) {
      checkOutDate = new Date(checkInDate);
      checkOutDate.setDate(checkOutDate.getDate() + 1);
  }

  // Eğer çıkış tarihi, giriş tarihinden önce ise hata mesajı ver ve işlemi durdur
  if (checkOutDate <= checkInDate) {
      alert('Çıkış tarihi, giriş tarihinden önce olamaz!');
      this.diffDays = 0;
      this.totalPrice = 0;
      this.reservationsModel.TotalPrice = 0;
      return;
  }

  // Tarihler arasındaki gün farkını hesapla
  const timeDiff = Math.abs(checkOutDate.getTime() - checkInDate.getTime());
  this.diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24)); // Gün sayısını hesapla

  // Toplam ücreti hesapla
  this.totalPrice = this.diffDays * price;
  this.reservationsModel.TotalPrice = this.totalPrice;
}


selectRoom(roomName: string){
  const selectedRoom = this.roomsModel
  .filter(room => room.roomName === roomName) // isAvailable kontrolü ile
  .shift();  // İlk müsait olan odayı seç

  if (selectedRoom) {
    // Seçilen odanın bilgilerini reservationsModel'e aktar
    this.reservationsModel.roomNumber = selectedRoom.roomNumber; 
    this.reservationsModel.RoomId = selectedRoom.id;
  } else {
    // Oda müsait değilse uyarı
    console.log('Seçilen oda türü için müsait oda bulunamadı');
  }
}


addReservation(form:NgForm){
if(form.valid){
  this.http.post<string>("Reservations/AddReservations" , this.reservationsModel, (res) => {
    this.swal.callToast(res.data, "success");
    this.reservationsModel = new ReservationsModel();
  })
}

}


}