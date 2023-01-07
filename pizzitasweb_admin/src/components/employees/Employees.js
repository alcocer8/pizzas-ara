import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';

import React, { useEffect, useState } from 'react';
import { Alert, Container } from 'react-bootstrap';


function EmployeesManagement() {
	
	const [state, setState] = useState ({
		items: [],
		isFetched: false
	});

	useEffect (() => {
		let url = process.env.REACT_APP_EMPLOYEES_ENDPOINT_BASEPATH + process.env.REACT_APP_EMPLOYEES_ENDPOINT_GETALL;

		fetch (url)
		.then ((response => response.json ()))
		.then ((json) => {
			setState ({
				items: json,
				isFetched: true
			})
		})
	});

	if (!state.isFetched) {
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
						state.items.map (item =>
							<tr key={item.idempleado}>
								<td>{item.name}</td>
								<td>{item.lastname}</td>
								<td>{item.celular}</td>
								<td>{item.username}</td>
								<td><Button variant="info" href="editemployees">Edit Employee</Button></td>
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

export default EmployeesManagement;