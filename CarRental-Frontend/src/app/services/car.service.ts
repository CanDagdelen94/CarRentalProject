import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../models/car';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  constructor(private httpClient: HttpClient) { }

  urlApi:string= "https://localhost:44343/api/";

  getCars():Observable<ListResponseModel<Car>>{
    let newPath = this.urlApi + "cars/getall";
    return this.httpClient.get<ListResponseModel<Car>>(newPath)
  }
  getCarByBrandId(brandId: number):Observable<ListResponseModel<Car>>{
    let newPath = this.urlApi + "cars/getbybrandid?id=" + brandId;
    return this.httpClient.get<ListResponseModel<Car>>(newPath)
  }
  getCarByColorName(colorName: string):Observable<ListResponseModel<Car>>{
    let newPath = this.urlApi + "brands/getbycolorname?colorname=" + colorName;
    return this.httpClient.get<ListResponseModel<Car>>(newPath)
  }
}
