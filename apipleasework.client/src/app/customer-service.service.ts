import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiUrl = 'http://localhost:5219';

  constructor(private http: HttpClient) { }

  getAllCustomers(): Observable<CustomerInformation[]> {
    return this.http.get<CustomerInformation[]>(this.apiUrl).pipe(
      catchError(error => {
        console.error('Error fetching customers:', error);
        throw error;
      })
    );
  }


}
