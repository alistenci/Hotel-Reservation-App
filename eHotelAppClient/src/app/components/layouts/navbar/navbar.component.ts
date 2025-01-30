import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {

  isLoggedIn: boolean = false;

  constructor(
    public auth:AuthService,
    private router: Router
  ){}
  ngOnInit(): void {
    this.checkStatus();
    this.auth.isAuth();
    console.log("navbar: " , this.auth.tokenDecode.username);
    
  }

  checkStatus(){
    if(localStorage.getItem("token")){
      this.isLoggedIn = true
    }else{
      this.isLoggedIn = false;
    }
  }

  signOut(){
    localStorage.removeItem('token');
    this.checkStatus();
    this.router.navigateByUrl("/login").then( () => {
      window.location.reload();
    });
  }

}
