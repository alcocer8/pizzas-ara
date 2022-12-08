import "./App.css";
import React, { useState } from "react";

import Home from "./components/home";
import EmployeesManagement from "./components/employees/employeesManagement";
import ProductoManagement from "./components/productos/ProductoManagemet";
import AddEmployee from "./components/employees/addEmployee";
import AddProducto from "./components/productos/AddProducto";
import EditEmployee from "./components/employees/editEmployee";
import EditProducto from "./components/productos/EditProducto";
import OrdenesManagement from "./components/orders/OrdenesManagement";
import Login from "./components/login/login";

import { Link, Routes, Route, useParams } from "react-router-dom";

import { Container, Navbar, NavItem } from "reactstrap";

import { useIdleTimer } from "react-idle-timer";

function MyApp(props) {
  const [token, setToken] = useState(""); // El parametro que le pasa al token es vacio cada vez que inicia la app
  useIdleTimer({ onIdle, onActive, timeout: 1000 * 60 * 10 });

  // necessary hack due to new version of rect-router doesn't pass
  // url params as props
  const Wrapper = (props) => {
    const params = useParams();

    switch (props.path) {
      case "employeesManagement":
        return <EditEmployee {...{ ...props, match: { params } }} />;
        break;
      case "productosManagement":
        return <EditProducto {...{ ...props, match: { params } }} />;
        break;
      default:
        break;
    }
  };

  function onActive(e) {}

  function onIdle(e) {
    console.log("User is idle");
    logout();
  }

  function logout() {
    setToken("");
    window.location.reload(false);
  }

  return (
    <React.Fragment>
      <Container style={{ maxWidth: "100%" }}>
        <Navbar expand="lg" className="navheader">
          <div className="collapse navbar-collapse">
            <ul className="navbar-nav">
              <NavItem>
                <Link to={"/"} className="nav-link">
                  Home
                </Link>
              </NavItem>
              <NavItem>
                <Link to={"/employeesManagement"} className="nav-link">
                  Employees Management
                </Link>
              </NavItem>
              <NavItem>
                <Link to={"/productosManagement"} className="nav-link">
                  Productos Management
                </Link>
              </NavItem>
              <NavItem>
                <Link to={"/ordenesManagement"} className="nav-link">
                  Ordenes Management
                </Link>
              </NavItem>
            </ul>
          </div>
          {token !== "" ? (
            <Link className="nav-link float-end" onClick={logout}>
              Logout
            </Link>
          ) : (
            <React.Fragment></React.Fragment>
          )}
        </Navbar>
      </Container>
      <br />

      <Routes>
        <Route path="/" element={<Home />} />

        {/* Empleados */}
        <Route
          exact
          path="/employeesManagement"
          element={<EmployeesManagement token={token} />}
        />
        <Route
          exact
          path="/addEmployee"
          element={
            <AddEmployee token={token} replace to="employeesManagement" />
          }
        />
        <Route
          exact
          path="/edit/:id"
          element={<Wrapper token={token} path={"employeesManagement"} />}
          replace
          to="employeesManagement"
        />

        {/* Productos */}
        <Route
          exact
          path="/productosManagement"
          element={<ProductoManagement token={token} />}
        />
        <Route
          exact
          path="/addProducto"
          element={
            <AddProducto token={token} replace to="productosManagement" />
          }
        />
        <Route
          exact
          path="/edit/producto/:id"
          element={<Wrapper token={token} path={"productosManagement"} />}
          replace
          to="productosManagement"
        />

        {/*  Ordenes */}
        <Route
          exact
          path="/ordenesManagement"
          element={<OrdenesManagement token={token} />}
        />

        {/* Login */}
        <Route exact path="/login" element={<Login setToken={setToken} />} />
      </Routes>
    </React.Fragment>
  );
}

export default MyApp;
