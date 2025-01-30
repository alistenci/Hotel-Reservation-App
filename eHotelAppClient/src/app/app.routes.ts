import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { LayoutsComponent } from './components/layouts/layouts.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ReservationsComponent } from './components/reservations/reservations.component';
import { AdminLayoutsComponent } from './components/admin-layouts/admin-layouts.component';
import { AdminHomeComponent } from './components/admin-layouts/admin-home/admin-home.component';
import { FloorComponent } from './components/admin-layouts/floor/floor.component';
import { VerifyCodeComponent } from './components/verify-code/verify-code.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { inject } from '@angular/core';
import { AuthService } from './services/auth.service';
import { AdminRoomsComponent } from './components/admin-layouts/admin-rooms/admin-rooms.component';
import { AdminReservationsComponent } from './components/admin-layouts/admin-reservations/admin-reservations.component';

export const routes: Routes = [
    {
        path: "",
        component: LayoutsComponent,
        children:[
            {
                path: "",
                component: HomeComponent
            },
            {
                path: "reservation",
                component: ReservationsComponent
            },
            {
                path: "login",
                component: LoginComponent
            },
            {
                path: "signup",
                component: SignUpComponent
            },
            {
                path: "verifycode",
                component: VerifyCodeComponent,
                canActivate: [() => inject(AuthService).isConfirmed()] // Bu rotaya erişim kısıtlaması eklenir
            }
            
        ]
    },
    {
        path: "admin",
        component: AdminLayoutsComponent,
        children:[
            {
                path: "",
                component: AdminHomeComponent
            },
            {
                path: "floor",
                component: FloorComponent
            },
            {
                path: "rooms",
                component: AdminRoomsComponent
            },
            {
                path: "reservation",
                component: AdminReservationsComponent
            }
        ]
    },
    {
        path: "**",
        component: NotFoundComponent
    }
];
