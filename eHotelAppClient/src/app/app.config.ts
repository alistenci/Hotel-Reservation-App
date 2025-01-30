import { ApplicationConfig, ChangeDetectionStrategy, LOCALE_ID, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideNativeDateAdapter } from '@angular/material/core';
import { provideHttpClient } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes),
    {provide: LOCALE_ID, useValue: 'tr'}, provideAnimationsAsync(), // Tarihi Türkçe yapmak için
    provideNativeDateAdapter(),
    provideAnimationsAsync(),
    provideHttpClient(),
  ]
};
