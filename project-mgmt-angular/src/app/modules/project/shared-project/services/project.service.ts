// Sprint 5 -- 1) Project service
import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProject } from '../models/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  url : string = "https://localhost:44313/api/Project";
    
  constructor(private http: HttpClient) { }

  // Sprint 5 -- 2) project apis via HttpClient - getall, getbyid, create, update, delete 
  public getAllProjects() : Observable<IProject[]>
  {
    return this.http.get<IProject[]>(this.url);
  }

  public getProjectById(id: string)
  {
    return this.http.get(`${this.url}/${id}`);
  }

  public createProject(formBody: any)
  {
    return this.http.post(this.url, formBody)
  }

  public updateProject(id: string, formBody: any) {
    return this.http.put(`${this.url}/${id}`, formBody);
  }
  
  public deleteProject(id: string) {
    return this.http.delete(`${this.url}/${id}`);
  }
}
