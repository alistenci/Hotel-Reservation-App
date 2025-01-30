import { Component, OnInit } from '@angular/core';
import { UserModel } from '../../../models/users-model';
import { HttpService } from '../../../services/http.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SwalService } from '../../../services/swal.service';

@Component({
  selector: 'app-admin-home',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './admin-home.component.html',
  styleUrl: './admin-home.component.css'
})
export class AdminHomeComponent implements OnInit {

  users: UserModel[] = [];

  constructor(
    private http: HttpService,
    private swal: SwalService
  ){}
  ngOnInit(): void {
    this.getAll();
  }


  getAll(){
    this.http.get<UserModel[]>("Auth/GetAllUsers" , (res) => {
      this.users = res.data;
    })
  }

  delete(id:string){
    this.swal.callSwal("Delete User", `Are you sure this user?`, () => {
      this.http.post<string>("Auth/DeleteUser", {id:id} , (res) => {
        this.swal.callToast(res.data, "info");
        this.getAll();
      })
    })
  }






}
