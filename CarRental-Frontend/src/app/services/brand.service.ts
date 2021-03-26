import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Brand } from '../models/brand';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  constructor(private httpClient: HttpClient) { }

  urlApi:string= "https://localhost:44343/api/";

  getBrands():Observable<ListResponseModel<Brand>>{
    let newPath = this.urlApi + "brands/getall";
    return this.httpClient.get<ListResponseModel<Brand>>(newPath)
  }
  getBrandById(brandId: number):Observable<ListResponseModel<Brand>>{
    let newPath = this.urlApi + "brands/getbyid?id=" + brandId;
    return this.httpClient.get<ListResponseModel<Brand>>(newPath)
  }
}
