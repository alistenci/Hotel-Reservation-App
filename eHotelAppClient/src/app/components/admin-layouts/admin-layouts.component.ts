import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AdminNavbarComponent } from "./admin-navbar/admin-navbar.component";
import { FloorComponent } from './floor/floor.component';

@Component({
  selector: 'app-admin-layouts',
  standalone: true,
  imports: [RouterOutlet, AdminNavbarComponent],
  templateUrl: './admin-layouts.component.html',
  styleUrl: './admin-layouts.component.css'
})
export class AdminLayoutsComponent {

}
