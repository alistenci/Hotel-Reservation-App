import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { UserModel } from '../../models/users-model';
import { HttpService } from '../../services/http.service';
import { Router } from '@angular/router';
import { SwalService } from '../../services/swal.service';
import { sendCodeModel } from '../../models/send-code.model';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.css'
})
export class SignUpComponent {

  signUpModel: UserModel = new UserModel();
  sendCodeModel: sendCodeModel = new sendCodeModel();

  constructor(
    private http: HttpService,
    private router: Router,
    private swal: SwalService
  ){}



  signUp(form:NgForm){
    if(form.valid){
      this.http.post<string>("Auth/CreateUser" , this.signUpModel, (res) => {
        this.swal.callToast(res.data, "success");
        const email = this.signUpModel.email;
        localStorage.setItem("signupSuccess", "true");
        this.router.navigate(['/verifycode'], { state: { email: email } });
        this.signUpModel = new UserModel();
      });
    }
  }
}
