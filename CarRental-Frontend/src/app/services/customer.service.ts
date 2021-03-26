import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private httpClient: HttpClient) { }

  urlApi:string= "https://localhost:44343/api/";

  getCustomers():Observable<ListResponseModel<Customer>>{
    let newPath = this.urlApi + "customers/getall";
    return this.httpClient.get<ListResponseModel<Customer>>(newPath)
  }
  getCustomerByUserId(userId:number):Observable<ListResponseModel<Customer>>{
    let newPath = this.urlApi + "customers/getcustomerbyuserid?userid=" + userId;
    return this.httpClient.get<ListResponseModel<Customer>>(newPath)
  }
}
