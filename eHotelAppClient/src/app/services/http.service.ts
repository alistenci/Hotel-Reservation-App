import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { api } from '../constants';
import { ResultModel } from '../models/result.model';
import { ErrorService } from './error.service';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  token: string = ""

  constructor(
    private _http: HttpClient,
    private error: ErrorService
  ) { 
    if(localStorage.getItem('token')){
      this.token = localStorage.getItem('token') ?? "";
    }
  }


  get<T>(apiUrl: string, callBack: (res: ResultModel<T>) => void, errCallBack?: (err: HttpErrorResponse) => void) {
    this._http.get<ResultModel<T>>(`${api}/${apiUrl}`
    ).subscribe({
      next: (res => {
        callBack(res);
      }),
      error: (err: HttpErrorResponse) => {
        this.error.errorHandler(err);
        if (errCallBack !== undefined) {
          errCallBack(err);
        }
      }
    });
  }
  

  post<T>(apiUrl:string, body:any, callBack: (res: ResultModel<T>) => void, errCallBack?: (err : HttpErrorResponse) => void) {
    const headers = {
      'Content-Type': 'application/json',
      "Authorization": "Bearer " + this.token
  };
    this._http.post<ResultModel<T>>(`${api}/${apiUrl}`,body , { headers }).subscribe({
      next: (res => {
        callBack(res);
      }),
      error: (err:HttpErrorResponse) => {
        this.error.errorHandler(err);
        if(errCallBack !== undefined){
          errCallBack(err);
        }
      }
    })
  }
}