// Sprint 5 -- Task model
export interface ITask {
  id: string,
  projectId: string,
  detail: string,
  assignedToUserId: string,
  status: number,
  createdOn: string
}