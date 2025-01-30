import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { MatTabsModule } from '@angular/material/tabs';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';
import { Router } from '@angular/router';
import { AdminRoomsModel } from '../../../admin-models/admin-rooms.model';
import { RoomType } from '../../../admin-models/admin-room-type.model';

@Component({
  selector: 'app-floor',
  standalone: true,
  imports: [CommonModule, FormsModule, MatTabsModule],
  templateUrl: './floor.component.html',
  styleUrl: './floor.component.css'
})
export class FloorComponent implements OnInit{

  roomsModel: AdminRoomsModel = new AdminRoomsModel();
  getAllRoomsModel: AdminRoomsModel[] = [];
  roomTypeModel: RoomType = new RoomType();
  roomTypes : RoomType[] = []; 
  floors = [1, 2, 3, 4, 5];
  filteredRooms: { [key: number]: AdminRoomsModel[] } = {};

  selectedFloorNumber: number = 0;


  isTrue: boolean = true ;

  constructor(
    private http : HttpService,
    private swal : SwalService,
    private router: Router
  ){}
  ngOnInit(): void {
   this.getAllRooms();
   this.getAllTypes();
  }


  selectFloor(floor: number) {
    this.roomsModel.floorNumber = floor;
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
        console.log(this.filteredRooms);
    });
}


  // getAllRooms(){
  //   this.http.get<AdminRoomsModel[]>("Room/GetAllRooms", (res) => {
  //     this.getAllRoomsModel = res.data;
  //     console.log(res.data);
  //   })
  // }

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
