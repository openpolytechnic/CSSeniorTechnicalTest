import React, { useState } from "react";
import { v4 as uuidv4 } from "uuid";
import "tailwindcss/tailwind.css";

function DyanmicForm() {
    const [customers, setCustomers] = useState([]);
    const [name, setName] = useState("");
    const [address, setAddress] = useState("");

    const handleNameChange = (e) => {
        setName(e.target.value);
    };

    const handleAddressChange = (e) => {
        setAddress(e.target.value);
    };

    const handleCreateCustomer = () => {
        const newCustomer = { id: uuidv4(), name, address };
        setCustomers([...customers, newCustomer]);
        setName("");
        setAddress("");
    };

    return (
        <div className="w-full max-w-sm mx-auto">
            <form className="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4">
                <div className="mb-4">
                    <label
                        className="block text-gray-700 text-sm font-bold mb-2"
                        htmlFor="name"
                    >
                        Name
                    </label>
                    <input
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        id="name"
                        type="text"
                        placeholder="Enter name"
                        value={name}
                        onChange={handleNameChange}
                    />
                </div>
                <div className="mb-4">
                    <label
                        className="block text-gray-700 text-sm font-bold mb-2"
                        htmlFor="address"
                    >
                        Address
                    </label>
                    <input
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        id="address"
                        type="text"
                        placeholder="Enter address"
                        value={address}
                        onChange={handleAddressChange}
                    />
                </div>
                <div className="flex items-center justify-between">
                    <button
                        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                        type="button"
                        onClick={handleCreateCustomer}
                    >
                        Create Customer
                    </button>
                </div>
            </form>
            {customers.map((customer) => (
                <form
                    key={customer.id}
                    className="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4"
                >
                    <div className="mb-4">
                        <label
                            className="block text-gray-700 text-sm font-bold mb-2"
                            htmlFor={`name-${customer.id}`}
                        >
                            Name
                        </label>
                        <input
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            id={`name-${customer.id}`}
                            type="text"
                            placeholder="Enter name"
                            defaultValue={customer.name}
                        />
                    </div>
                    <div className="mb-4">
                        <label
                            className="block text-gray-700 text-sm font-bold mb-2"
                            htmlFor={`address-${customer.id}`}
                        >
                            Address
                        </label>
                        <input
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            id={`address-${customer.id}`}
                            type="text"
                            placeholder="Enter address"
                            defaultValue={customer.address}
                        />
                    </div>
                </form>
            ))}
        </div>

    );
}

export default DyanmicForm;