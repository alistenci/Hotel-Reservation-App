import { Component } from '@angular/core';
import { LoginModel } from '../../models/login.model';
import { HttpService } from '../../services/http.service';
import { Router, RouterLink } from '@angular/router';
import { FormsModule, NgForm } from '@angular/forms';
import { SwalService } from '../../services/swal.service';
import { LoginResponseModel } from '../../models/login-response.model';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'

})
export class LoginComponent {

  login: LoginModel = new LoginModel();

  constructor(
    private _http : HttpService,
    private router: Router,
    private swal: SwalService
    ) {}


  signIn(form:NgForm){
    if(form.valid){
      this._http.post<LoginResponseModel>("Login/Login", this.login, (res)=> {
        localStorage.setItem("token", res.data.token);
        this.router.navigateByUrl("/").then(() => {
          window.location.reload();
        });
      });
    }
  }
}
