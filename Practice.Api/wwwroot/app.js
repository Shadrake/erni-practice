/* Configuración y mapeos de estado */
// Endpoint base de la API
const API_URL = "/api/tasks";

// Mapea el estado (enum del backend) a la columna del DOM
// Se usa al pintar las tareas
const statusToColumnId = {
  0: "backlog",
  1: "todo",
  2: "inprogress",
  3: "done",
  4: "closed"
};

// Mapeo inverso: columna del DOM -> estado del backend
// Se usa al soltar una tarjeta en una columna
const columnIdToStatus = {
  "backlog": 0,
  "todo": 1,
  "inprogress": 2,
  "done": 3,
  "closed": 4
};

/* Comunicación con la API */
// Actualiza únicamente el estado de una tarea existente
async function updateTaskStatus(taskId, newStatus) {
  await fetch(`${API_URL}/${taskId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({
      status: newStatus
    })
  });
}

/* Renderizado del tablero */
// Carga las tareas desde la API y las pinta en sus columnas
async function loadTasks() {
  const response = await fetch(API_URL);
  const tasks = await response.json();

  // Limpia las tarjetas actuales sin recrear las columnas
  Object.values(statusToColumnId).forEach(columnId => {
    const column = document.getElementById(columnId);
    if (!column) return;

    column.querySelectorAll(".task").forEach(task => task.remove());
  });

  // Crea y coloca cada tarjeta según su estado
  tasks.forEach(task => {
    const columnId = statusToColumnId[task.status];
    const column = document.getElementById(columnId);
    if (!column) return;

    const taskDiv = document.createElement("div");
    taskDiv.className = "task";
    taskDiv.textContent = task.title;

    // Permite que la tarjeta sea arrastrable
    taskDiv.draggable = true;
    taskDiv.dataset.taskId = task.id;

    // Guarda el id de la tarea al iniciar el drag
    taskDiv.addEventListener("dragstart", e => {
      e.dataTransfer.setData("text/plain", task.id);
    });

    column.appendChild(taskDiv);
  });
}



/* Drag & Drop de columnas */
// Configura las columnas como zonas válidas de drop
function setupDragAndDrop() {
  document.querySelectorAll(".column").forEach(column => {

    // Necesario para permitir el drop
    column.addEventListener("dragover", e => {
      e.preventDefault();
    });

    // Al soltar una tarjeta se actualiza su estado en backend
    column.addEventListener("drop", async e => {
      e.preventDefault();

      const taskId = e.dataTransfer.getData("text/plain");
      const newStatus = columnIdToStatus[column.id];

      await updateTaskStatus(taskId, newStatus);
      loadTasks();
    });

  });
}

/* Inicialización de la aplicación */
// Se configuran los eventos una sola vez
setupDragAndDrop();

// Primera carga del tablero
loadTasks();