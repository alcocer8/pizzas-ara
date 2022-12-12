import "./App.css";
import React, { useState } from "react";

import Home from "./components/home";
import ProductoManagement from "./components/productos/ProductoManagemet";
import EditProducto from "./components/productos/EditProducto";
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
      case "ClientManagement":
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
                <Link to={"/clientManagement"} className="nav-link">
                  Panel
                </Link>
              </NavItem>
              <NavItem>
                <Link to={"/productosManagement"} className="nav-link">
                  Productos Management
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

        {/* Clientes */}
        


        {/* Productos */}
        <Route
          exact
          path="/productosManagement"
          element={<ProductoManagement token={token} />}
        />

        {/* Login */}
        <Route exact path="/login" element={<Login setToken={setToken} />} />
      </Routes>
    </React.Fragment>
  );
}

export default MyApp;
