import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {GuineaPigModel} from "../models/guineaPig.model";

@Injectable({
  providedIn: 'root'
})
export class GuineaPigService {
  private readonly serviceUrl = environment.apiUrl + 'GuineaPigs/';

  constructor(private http: HttpClient) { }

  getGuineaPigs(): Observable<GuineaPigModel[]> {
    return this.http.get<GuineaPigModel[]>(this.serviceUrl);
  }

  getGuineaPigById(guineaPugId: number): Observable<GuineaPigModel> {
    return this.http.get<GuineaPigModel>(this.serviceUrl + guineaPugId);
  }

  insertGuineaPig(guineaPig: GuineaPigModel): Observable<GuineaPigModel> {
    return this.http.post<GuineaPigModel>(this.serviceUrl, guineaPig);
  }

  updateGuineaPig(guineaPigId: number, guineaPig: GuineaPigModel): Observable<GuineaPigModel> {
    return this.http.put<GuineaPigModel>(this.serviceUrl + guineaPigId, guineaPig);
  }

  deleteGuineaPig(guineaPigId: number): Observable<boolean> {
    return this.http.delete<boolean>(this.serviceUrl + guineaPigId);
  }
}
