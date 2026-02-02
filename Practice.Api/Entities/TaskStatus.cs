namespace Practice.Api.Entities;

// Estados posibles de la tarea
public enum TaskStatus
{
    Backlog = 0,
    ToDo = 1,
    InProgress = 2,
    Done = 3,
    Closed = 4
}