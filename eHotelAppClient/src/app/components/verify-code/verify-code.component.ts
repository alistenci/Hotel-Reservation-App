import { Component, OnInit } from '@angular/core';
import { UserModel } from '../../models/users-model';
import { FormsModule, NgForm } from '@angular/forms';
import { HttpService } from '../../services/http.service';
import { ActivatedRoute, Router } from '@angular/router';
import { SwalService } from '../../services/swal.service';
import { sendCodeModel } from '../../models/send-code.model';
import { VerifyModel } from '../../models/verify-code.model';

@Component({
  selector: 'app-verify-code',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './verify-code.component.html',
  styleUrl: './verify-code.component.css'
})
export class VerifyCodeComponent implements OnInit {

  sendCodeModel: sendCodeModel = new sendCodeModel();
  verifyCodeModel: VerifyModel = new VerifyModel();

  email: string = "";

  constructor(
    private http : HttpService,
    private router : Router,
    private swal: SwalService,
    private route: ActivatedRoute
  ){}
  ngOnInit(): void {
    this.verifyCodeModel.Email = history.state.email;
    console.log(history.state.email);
    console.log(this.verifyCodeModel);
    this.sendVerifyCode();
  }

  sendVerifyCode(){
      this.http.post<string>("Auth/SendCode" , { email: this.verifyCodeModel.Email} , (res) => {
        this.swal.callToast(res.data, "success");
      }, (err) => {
        this.swal.callToast(err.error.errorMessages , "error");
      });
  }

  // Kullanıcı doğrulama kodunu girdikten sonra çağrılan method
  verifyCode(form: NgForm) {
    if (form.valid) {
      this.http.post<string>("Auth/VerifyCode", this.verifyCodeModel, (res) => {
        this.swal.callToast(res.data, "success");
        localStorage.removeItem("signupSuccess");
        this.router.navigateByUrl("/");
      }, (err) => {
        this.swal.callToast("Verification failed", "error");
        console.log(err.message);
      });
    }
  }
}