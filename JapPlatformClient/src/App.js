import { Route, Routes } from "react-router-dom";

import Sidebar from "components/Sidebar/Sidebar";
import {
  Login,
  Programs,
  SelectionDetails,
  SelectionEdit,
  SelectionNew,
  Selections,
  StudentDetails,
  StudentEdit,
  StudentNew,
  Students,
} from "pages";

import RequireAuth from "RequireAuth";
import StudentProfile from "pages/Students/StudentProfile";
import Dashboard from "pages/Admin/Dashboard";

const App = () => {
  return (
    <>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route element={<RequireAuth allowedRoles={["Admin"]} />}>
          <Route element={<Sidebar />}>
            <Route path="/dashboard" element={<Dashboard />} />
            <Route path="/programs" element={<Programs />} />
            <Route path="/students" element={<Students />} />
            <Route path="/students/new" element={<StudentNew />} />
            <Route path="/students/:studentId" element={<StudentDetails />} />
            <Route path="/students/:studentId/edit" element={<StudentEdit />} />
            <Route path="/selections" element={<Selections />} />
            <Route path="/selections/new" element={<SelectionNew />} />
            <Route
              path="/selections/:selectionId"
              element={<SelectionDetails />}
            />
            <Route
              path="/selections/:selectionId/edit"
              element={<SelectionEdit />}
            />
          </Route>
        </Route>
        <Route element={<RequireAuth allowedRoles={["Student"]} />}>
          <Route path="/profile" element={<StudentProfile />} />
        </Route>
      </Routes>
    </>
  );
};

export default App;
