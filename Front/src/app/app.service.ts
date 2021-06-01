import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})

export class AppService {
  readonly rootURL = 'https://localhost:5001/api';
  constructor(private http: HttpClient) { }
      httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      }
      getEventos(){
        return this.http.get(`${this.rootURL}/Eventos`);
      }
      postEvento(formData: any){
        return this.http.post(`${this.rootURL}/Eventos`, formData);
      }
      putEvento(id: string, formData: any){
        return this.http.put(`${this.rootURL}/Eventos/${id}`, formData);
      }

      deleteEvento(id: string){
        return this.http.delete(`${this.rootURL}/Eventos/${id}`);
      }
}
