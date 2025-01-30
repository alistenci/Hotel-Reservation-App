import { Injectable } from '@angular/core';
import { SwalService } from './swal.service';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(
    private swal: SwalService
  ) { }

  errorHandler(err: HttpErrorResponse) {
    console.log(err);
    let message = "Error!";

    if (err.status === 0) {
        message = "API is not available";
    } else if (err.status === 404) {
        message = "Not Found";
    } else if (err.status === 401) {
        message = "Unauthorized";
    } else if (err.status === 500) {
        message = "";

        // errorMessages varsa ve iterable ise döngüye al
        if (err.error && Array.isArray(err.error.errorMessages)) {
            for (const e of err.error.errorMessages) {
                message += e + "\n";
            }
        } else {
            message = "An unexpected server error occurred.";
        }
    }

    this.swal.callToast(message, "error");
  }
}
