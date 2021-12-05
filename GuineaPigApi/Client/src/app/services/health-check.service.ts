import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {HealthCheckModel} from "../models/healthCheck.model";

@Injectable({
  providedIn: 'root'
})
export class HealthCheckService {
  private readonly serviceUrl = environment.apiUrl + 'HealthChecks/';

  constructor(private http: HttpClient) {
  }

  getHealthChecks(): Observable<HealthCheckModel[]> {
    return this.http.get<HealthCheckModel[]>(this.serviceUrl);
  }

  getHealthCheckById(healthCheckId: number): Observable<HealthCheckModel> {
    return this.http.get<HealthCheckModel>(this.serviceUrl + healthCheckId);
  }

  getHealthChecksByGuineaPigId(guineaPigId: number): Observable<HealthCheckModel[]> {
    return this.http.get<HealthCheckModel[]>(this.serviceUrl + 'guineaPig/' + guineaPigId);
  }

  insertHealthCheck(healthCheck: HealthCheckModel): Observable<HealthCheckModel> {
    return this.http.post<HealthCheckModel>(this.serviceUrl, healthCheck);
  }

  updateHealthCheck(healthCheckId: number, healthCheck: HealthCheckModel): Observable<HealthCheckModel> {
    return this.http.put<HealthCheckModel>(this.serviceUrl + healthCheckId, healthCheck);
  }

  deleteHealthCheck(healthCheckId: number): Observable<boolean> {
    return this.http.delete<boolean>(this.serviceUrl + healthCheckId);
  }
}
