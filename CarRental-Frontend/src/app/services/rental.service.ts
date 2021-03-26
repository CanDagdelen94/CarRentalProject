import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Rental } from '../models/rental';

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  constructor(private httpClient:HttpClient) { }

  urlApi:string= "https://localhost:44343/api/";

  getRentals():Observable<ListResponseModel<Rental>>{
    let newPath = this.urlApi + "rentals/getall";
    return this.httpClient.get<ListResponseModel<Rental>>(newPath);
  }
  getRentalByCustomerId(customerId: number):Observable<ListResponseModel<Rental>>{
    let newPath = this.urlApi + "rentals/getbycustomerid?customerid=" + customerId;
    return this.httpClient.get<ListResponseModel<Rental>>(newPath);
  }

}
