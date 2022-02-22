// Sprint 5 -- 1) Task service
import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITask } from '../models/task';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  url : string = "https://localhost:44313/api/Task1";
    
  constructor(private http: HttpClient) { }

  // Sprint 5 -- 2) task apis via HttpClient - getall, getbyid, create, update, delete 
  public getAllTasks() : Observable<ITask[]>
  {
    return this.http.get<ITask[]>(this.url);
  }

  public getTaskById(id: string)
  {
    return this.http.get(`${this.url}/${id}`);
  }

  public createTask(formBody: any)
  {
    return this.http.post(this.url, formBody)
  }

  public updateTask(id: string, formBody: any) {
    return this.http.put(`${this.url}/${id}`, formBody);
  }
  
  public deleteTask(id: string) {
    return this.http.delete(`${this.url}/${id}`);
  }
}
