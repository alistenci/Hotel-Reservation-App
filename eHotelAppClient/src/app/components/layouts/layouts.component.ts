import { Component } from '@angular/core';
import { NavbarComponent } from './navbar/navbar.component';
import { RouterOutlet } from '@angular/router';
import { FloorComponent } from '../admin-layouts/floor/floor.component';

@Component({
  selector: 'app-layouts',
  standalone: true,
  imports: [ RouterOutlet ,NavbarComponent],
  templateUrl: './layouts.component.html',
  styleUrl: './layouts.component.css'
})
export class LayoutsComponent {

}
