import { Component } from '@angular/core';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
   imports: [RouterOutlet, MatSlideToggleModule],
  template: "<router-outlet></router-outlet>"
})
export class AppComponent {
}
