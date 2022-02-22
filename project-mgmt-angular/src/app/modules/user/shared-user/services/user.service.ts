// Sprint 5 -- 1) User service
import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  url : string = "https://localhost:44313/api/User";
    
  constructor(private http: HttpClient) { }

  // Sprint 5 -- 2) user apis via HttpClient - getall, getbyid, create, update, delete 
  public getAllUsers() : Observable<IUser[]>
  {
    return this.http.get<IUser[]>(this.url);
  }

  public getUserById(id: string)
  {
    return this.http.get(`${this.url}/${id}`);
  }

  public createUser(formBody: any)
  {
    return this.http.post(this.url, formBody)
  }

  public updateUser(id: string, formBody: any) {
    return this.http.put(`${this.url}/${id}`, formBody);
  }
  
  public deleteUser(id: string) {
    return this.http.delete(`${this.url}/${id}`);
}
}
