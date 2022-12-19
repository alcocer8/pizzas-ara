import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';

import React from 'react';
import { useLocation } from 'react-router-dom';
// import axios from 'axios';
import { Alert, Container } from 'react-bootstrap';


class EmployeesManagement extends React.Component {
	constructor (props) {
		super (props);

		this.state = {
			items: [],
			isFetched: false,
		};

		this.EMPLOYESS_ENDPOINT_BASEPATH = process.env.REACT_APP_EMPLOYEES_ENDPOINT_BASEPATH;
		this.EMPLOYEES_ENDPOINT_GETALL = process.env.REACT_APP_EMPLOYEES_ENDPOINT_GETALL;
	}

	componentDidMount () {
		let url = this.EMPLOYESS_ENDPOINT_BASEPATH + this.EMPLOYEES_ENDPOINT_GETALL;

		fetch (url)
		.then ((response => response.json ()))
		.then ((json) => {
			this.setState ({
				items: json,
				isFetched: true
			});
		})
	}

	render () {
		if (!this.state.isFetched) {
			return (
				<Container>
					<Alert color="primary">Loading...</Alert>
				</Container>
			);
		}

		return (
			<div>
			<Table striped bordered hover>
				<thead>
				<tr>
					<th>First Name</th>
					<th>Last Name</th>
					<th>Cellphone</th>
					<th>Username</th>
					<th>Actions</th>
				</tr>
				</thead>
				<tbody>
					{
						this.state.items.map (item =>
							<tr key={item.idempleado}>
								<td>{item.name}</td>
								<td>{item.lastname}</td>
								<td>{item.celular}</td>
								<td>{item.username}</td>
								<td><a href="editemployees">Edit Employee</a></td>
							</tr>
						)
					}
				</tbody>
			</Table>
			<Button variant="info" type="submit" href="/addemployees">
				Add Employees
			</Button>
		
			</div>
		
		);

	}
}

//other necessary hack to get around react-router v6
//heavy hooks utlization
function WithRouter (Component) {
    function ComponentWithRouterProps (props) {
        let location = useLocation ();
        return (
            <Component {...props}{...{location}} />
        )
    }

    return ComponentWithRouterProps;
}

export default WithRouter (EmployeesManagement);