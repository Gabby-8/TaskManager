import { useEffect, useState } from "react";
import "./App.css";

function App() {
  const [tasks, setTasks] = useState([]);
  const [title, setTitle] = useState("");

  useEffect(() => {
    fetch("https://localhost:5001/api/tasks")
      .then(res => res.json())
      .then(data => setTasks(data));
  }, []);

  const addTask = async () => {
    if (!title) return;

    const response = await fetch("https://localhost:5001/api/tasks", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ title, isCompleted: false })
    });

    const newTask = await response.json();
    setTasks([...tasks, newTask]);
    setTitle("");
  };

  return (
    <div className="container">
      <h1>Task Manager</h1>

      <div className="input-group">
        <input
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          placeholder="New task..."
        />
        <button onClick={addTask}>Add</button>
      </div>

      <ul>
        {tasks.map(task => (
          <li key={task.id} className={task.isCompleted ? "done" : ""}>
            {task.title}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;
