import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Color } from '../models/color';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root'
})
export class ColorService {

  constructor(private httpClient: HttpClient) { }

  urlApi:string= "https://localhost:44343/api/";

  getColors():Observable<ListResponseModel<Color>>{
    let newPath = this.urlApi + "colors/getall";
    return this.httpClient.get<ListResponseModel<Color>>(newPath)
  }


}
