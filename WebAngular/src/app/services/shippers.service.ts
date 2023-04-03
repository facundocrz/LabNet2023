import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Shippers } from '../models/shippers';

@Injectable({
  providedIn: 'root',
})
export class ShippersService {
  private apiUrl = '/api/shippers';

  constructor(private http: HttpClient) {}

  get(): Observable<Shippers[]> {
    return this.http.get<Shippers[]>(this.apiUrl);
  }

  getById(id: number): Observable<Shippers> {
    return this.http.get<Shippers>(`${this.apiUrl}/${id}`);
  }

  add(shipper: Shippers): Observable<Shippers> {
    return this.http.post<Shippers>(this.apiUrl, shipper);
  }

  update(shipper: Shippers): Observable<Shippers> {
    const url = `${this.apiUrl}/${shipper.ID}`;
    return this.http.put<Shippers>(url, shipper);
  }

  delete(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url);
  }
}
