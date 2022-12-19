import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';

//Importamos los components creados
import NavBarExample from './components/layouts/navbar';
import Home from './components/Home';
import Login from './components/employees/Login';
import ProductsManagement from './components/products/ProductsManagement';
import OrdersManagement from './components/OrdersManagement';
import Employees from './components/employees/Employees';
import AddEmployees from './components/employees/AddEmployees';
import EditEmployees from './components/employees/EditEmployees';
import EditProduct from './components/products/EditProduct';
import AddProduct from './components/products/AddProduct';


function App() {
  return (
        <div className="App">
    <BrowserRouter>
    <Routes>
      <Route path='/' element={ <NavBarExample /> }>
        <Route index element={ <Home /> } />
        <Route path='employeesmanagement' element={ <Login/> } />
        <Route path='productsmanagement' element={ <ProductsManagement/> } />
        <Route path='ordersmanagement' element={ <OrdersManagement/> } />
        <Route path='employees' element={ <Employees/> } />
        <Route path='addemployees' element={ <AddEmployees/> } />
        <Route path='editemployees' element={ <EditEmployees/> } />
        <Route path='editproduct' element={ <EditProduct/> } />
        <Route path='addproduct' element={ <AddProduct/> } />

        <Route path='*' element={ <Navigate replace to="/"/> }/>
      </Route>
    </Routes> 
    </BrowserRouter>
    </div>
  );
}
export default App;
