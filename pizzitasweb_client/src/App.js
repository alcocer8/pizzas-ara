import './App.css';
import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';

//Importamos los components creados
import NavBarExample from './components/layouts/navbar';
import Inicio from './components/Inicio';
import Ordenes from './components/Ordenes';
import Contacto from './components/Contacto';
import Login from './components/Login';
import Carrito from './components/Carrito';

function App() {
  return (
        <div className="App">
    <BrowserRouter>
    <Routes>
      <Route path='/' element={ <NavBarExample /> }>
        <Route index element={ <Inicio /> } />
        <Route path='carrito' element={ <Carrito /> } />
        <Route path='ordenes' element={ <Ordenes /> } />
        <Route path='contacto' element={ <Contacto/> } />
        <Route path='login' element={ <Login/> } />
        <Route path='*' element={ <Navigate replace to="/"/> }/>
      </Route>
    </Routes> 
    </BrowserRouter>
    </div>
  );
}
export default App;
