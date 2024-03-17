import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CRUDService {
  private apiUrl = 'http://localhost:5219';

  constructor(private http: HttpClient) { }

  create(data: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, data).pipe(
      catchError(error => {
        console.error('Error creating data:', error);
        throw error;
      })
    );
  }
  
  getAll(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl).pipe(
      catchError(error => {
        console.error('Error fetching data:', error);
        throw error;
      })
    );
  }

  update(id: number, data: any): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put<any>(url, data).pipe(
      catchError(error => {
        console.error(`Error updating data with ID ${id}:`, error);
        throw error;
      })
    );
  }
  
  delete(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<any>(url).pipe(
      catchError(error => {
        console.error(`Error deleting data with ID ${id}:`, error);
        throw error;
      })
    );
  }
}
