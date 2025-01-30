import { CommonModule } from '@angular/common';
import {  ChangeDetectorRef, Component, model, OnInit, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { MatTabsModule } from '@angular/material/tabs';
import { AdminRoomsModel } from '../../../admin-models/admin-rooms.model';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';
import { RoomType } from '../../../admin-models/admin-room-type.model';
import { AuthService } from '../../../services/auth.service';
import { v4 as uuidv4 } from 'uuid'; // Import uuidv4 from 'uuid' package
import { adminReservationsModel } from '../../../admin-models/admin-reservations.moel';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCalendarCellClassFunction, MatDatepicker, MatDatepickerModule } from '@angular/material/datepicker';
import { GetReservationsModel } from '../../../admin-models/get-reservations-model';

@Component({
  selector: 'app-admin-reservations',
  standalone: true,
  imports: [CommonModule, FormsModule, MatTabsModule, MatFormFieldModule,MatInputModule, MatDatepickerModule],
  templateUrl: './admin-reservations.component.html',
  styleUrl: './admin-reservations.component.css',
})
export class AdminReservationsComponent implements OnInit {
  filledDateRanges: { start: Date; end: Date }[] = [];
  roomsModel: AdminRoomsModel = new AdminRoomsModel();
  getAllRoomsModel: AdminRoomsModel[] = [];
  roomTypeModel: RoomType = new RoomType();
  roomTypes : RoomType[] = [];
  filteredRooms: { [key: number]: AdminRoomsModel[] } = {};
  adminReservationsModel : adminReservationsModel = new adminReservationsModel();
  roomPrice : number = 0;
  totalPrice : number = 0;

  getAllReservationsModel: GetReservationsModel = new GetReservationsModel();



  isTrue : boolean = false;
  floors = [1, 2, 3, 4, 5];

  selected = model<Date | null>(null);
  @ViewChild('startDatePicker') startDatePicker! : MatDatepicker<Date>


  constructor(
    public http: HttpService,
    public swal : SwalService,
    public auth: AuthService,
    public cdr: ChangeDetectorRef
  ){}
  ngOnInit(): void {
    this.getAllRooms();
  }

loadCheckDates(Id: string): void {
  this.http.get<{ checkInDate: string, checkOutDate: string }[]>(`Reservations/GetAllReservationsDate?roomId=${Id}`, (res) => {
    if (res.data && Array.isArray(res.data)) {
      this.filledDateRanges = res.data.map((date) => {
        const checkInDate = new Date(date.checkInDate);
        const checkOutDate = new Date(date.checkOutDate);

        return {
          start: new Date(Date.UTC(checkInDate.getFullYear(), checkInDate.getMonth(), checkInDate.getDate())), //+0
          end: new Date(Date.UTC(checkOutDate.getFullYear(), checkOutDate.getMonth(), checkOutDate.getDate())) //+1
        };
      });

      console.log(this.filledDateRanges); // Debug için
    } else {
      console.error('Yanıt verisi beklenen formatta değil:', res);
    }
  },
  (err) => {
    console.error('API çağrısı sırasında hata oluştu', err);
  });
}
  dateClass: MatCalendarCellClassFunction<Date> = (date: Date, view: string) => {
    if (view === 'month') {
      return this.filledDateRanges.some(range =>
        date >= range.start && date <= range.end
      ) ? 'example-custom-date-class' : '';
    }
    return '';
  };
  
  // dateFilter = (date: Date | null): boolean => {
  //   if (!date) return false;
  //   // Dolu tarihlerin seçilemez olmasını sağla
  //   const isDateDisabled = this.filledDateRanges.some(range =>
  //     date >= range.start && date <= range.end
  //   );
  //   return !isDateDisabled;
  // };

  selectRoom(rooms: number, id:string) {
    this.adminReservationsModel.roomNumber = rooms;
    this.adminReservationsModel.RoomId = id;
  }

selectFloor(floor: number) {
  this.adminReservationsModel.floorNumber = floor;
}

getAllTypes(){
  this.http.get<RoomType[]>("Room/GetAllTypes", (res) => {
    this.roomTypes = res.data;
  })
}

getAllRooms(){
  this.http.get<AdminRoomsModel[]>("Room/GetAllRooms", (res) => {
      this.getAllRoomsModel = res.data;
      this.floors.forEach(floor => {
          this.filteredRooms[floor] = this.getAllRoomsModel.filter(room => room.floorNumber === floor);
      });
  });
}


addReservation(form:NgForm){
  if(form.valid){
    this.http.post<string>("Reservations/AddReservations", this.adminReservationsModel, (res) => {
      this.swal.callToast(res.data , "success");
      this.adminReservationsModel = new adminReservationsModel();
      this.getAllRooms();
    })
    }
  }


  openStartDatePicker(){
    this.startDatePicker.open();
  }

  sendPrice(price:number){
    this.roomPrice = price;
    this.totalPrice = 0;
  }

  hesapla(){
   const checkInDate = this.adminReservationsModel.CheckInDate;
   const checkOutDate = this.adminReservationsModel.CheckOutDate;

   const timeDiff = Math.abs(new Date(checkOutDate).getTime() - new Date(checkInDate).getTime());
   const diffDays = Math.ceil(timeDiff / (1000*3600*24)); // gün sayısını elde etmek için
   this.totalPrice = diffDays * this.roomPrice;
  }
}