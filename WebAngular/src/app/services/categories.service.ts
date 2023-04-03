import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Categories } from '../models/categories';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  private apiUrl = '/api/categories';

  constructor(private http: HttpClient) {}

  get(): Observable<Categories[]> {
    return this.http.get<Categories[]>(this.apiUrl);
  }

  getById(id: number): Observable<Categories> {
    return this.http.get<Categories>(`${this.apiUrl}/${id}`);
  }

  add(category: Categories): Observable<Categories> {
    return this.http.post<Categories>(this.apiUrl, category);
  }

  update(category: Categories): Observable<Categories> {
    const url = `${this.apiUrl}/${category.ID}`;
    return this.http.put<Categories>(url, category);
  }

  delete(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url);
  }
}
