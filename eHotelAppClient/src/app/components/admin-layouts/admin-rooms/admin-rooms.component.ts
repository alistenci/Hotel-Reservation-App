import { Component, OnInit } from '@angular/core';
import { RoomFeature } from '../../../admin-models/admin-room-feature.model';
import { RoomType } from '../../../admin-models/admin-room-type.model';
import { AdminRoomsModel } from '../../../admin-models/admin-rooms.model';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { HttpService } from '../../../services/http.service';
import { FormsModule, NgForm } from '@angular/forms';
import { SwalService } from '../../../services/swal.service';
import { CommonModule } from '@angular/common';
import { MatTabsModule} from '@angular/material/tabs';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-admin-rooms',
  standalone: true,
  imports: [FormsModule, CommonModule, MatCardModule, MatTabsModule],
  templateUrl: './admin-rooms.component.html',
  styleUrl: './admin-rooms.component.css'
})
export class AdminRoomsComponent implements OnInit {

  roomFeatureModel: RoomFeature = new RoomFeature();
  roomTypeModel: RoomType = new RoomType();
  roomsModel: AdminRoomsModel = new AdminRoomsModel();
  roomTypes : RoomType[] = [];
  roomFeatures: RoomFeature[] = [];
  allRooms: AdminRoomsModel[] = [];

  constructor(
    private router: Router,
    private auth: AuthService,
    private http: HttpService,
    private swal: SwalService
  ){}
  ngOnInit(): void {
    this.getAllTypes();
    this.getAllFeatures();
    this.getAllRooms();
  }

  getAllTypes(){
    this.http.get<RoomType[]>("Room/GetAllTypes", (res) => {
      this.roomTypes = res.data;
      console.log(res.data);
    })
  }

  getAllFeatures(){
    this.http.get<RoomFeature[]>("Room/GetAllFeatures", (res) => {
      this.roomFeatures = res.data;
    })
  }

  getAllRooms(){
    this.http.get<AdminRoomsModel[]>("Room/GetAllRooms", (res) => {
      this.allRooms = res.data;
    })
  }


  addRoomFeature(form:NgForm){
    if(form.valid){
    this.http.post<string>("Room/AddRoomFeature", this.roomFeatureModel, (res) => {
      this.swal.callToast(res.data, "success");
      this.roomFeatureModel = new RoomFeature();
      this.getAllFeatures();
    })
  }
}

addRoomType(form:NgForm){
  if(form.valid){
  this.http.post<string>("Room/AddRoomTypes", this.roomTypeModel, (res) => {
    this.swal.callToast(res.data, "success");
    this.roomTypeModel = new RoomType();
    this.getAllTypes();
  })
}
}



addRoom(form:NgForm){
  if(form.valid){
    this.http.post<string>("Room/AddRoom", this.roomsModel, (res) => {
      this.swal.callToast(res.data, "success");
      this.roomsModel = new AdminRoomsModel();
      this.getAllRooms();
    })
  }
}

}
