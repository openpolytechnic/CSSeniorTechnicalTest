
import React, { useState, useEffect } from "react";
import axios from 'axios'
import { v4 as uuidv4 } from "uuid";

const Order = () => {

    const [data, setData] = useState([])

    const [orderSummary, setOrderSummary] = useState([null])

    const menu = ["standard", "weekend", "catering"]
    const customerList = ["Child", "SeniorCitizen", "Student", "Standard"]

    const [selectedMenu, setSelectedMenu] = useState('standard');

    const [customers, setCustomers] = useState([])
    const [customerType, setCustomerType] = useState('standard')

    const [itemId, setItemId] = useState(0)
    const [quantity, setQuantity] = useState(1)
    const [item, setItem] = useState(0)

    const [items, setItems] = useState([])

    const [customerId, setCustomerId] = useState(1)

    /*const addToOrder = (name, description, price) => setItems([...items, { name, description, price }])*/


    const addCustomer = () => {

        if (customerId > 1) alert("Multiple Customers doesn't work...")

        console.log(orderSummary)

        setCustomerId(customerId + 1)

        const newCustomer = { id: customerId, customerType, itemId, quantity };
        /*const newCustomer = { id: uuidv4(), customerType, itemId, quantity };*/
        setCustomers([...customers, newCustomer]);

        setCustomerType('')
        setItemId(0)
        setQuantity(0)

    }

    ///// first attempt. no discount and surcharge labels
    const addToOrder = () => {

        // no message :)
        if (quantity < 1) return;

        const findItem = data?.find(item => item.id === Number(itemId))

        const name = findItem.name
        const description = findItem.description
        const cost = findItem.cost
        const id = findItem.id

        const idx = items.findIndex(item => item.id === Number(itemId))

        if (idx !== -1) {

            items[idx].quantity += quantity

        }
        else {
            setItems([...items, { id, name, description, cost, quantity, selectedMenu, customerType }])
        }

        setQuantity(0)
        setItemId(0)

    }

    const handleCustomerTypeChange = (e) => {
        setCustomerType(e.target.value)
    }

    const handleItemChange = (e) => {
        setItemId(e.target.value)
    }

    const handleQuantityChange = (e) => {
        setQuantity(Number(e.target.value))
    }

    const handleSelectChange = (e) => {

        setItemId(e.target.value)

    }

    const placeOrder = () => {

        const api = axios.create({
            baseURL: 'https://localhost:44421',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        const formData = new FormData();

        formData.append('items', JSON.stringify(items));

        api.post('/api/order/placeorder', items)
            .then(response => {
                setOrderSummary(response.data)
                console.log(response.data);
            })
            .catch(error => {
                console.error(error);
            });

    }

    const toggleButtonMenu = (e, menu) => {

        /*console.log(document.querySelectorAll('.btn-menus').forEach(item => item.classList.remove('active')))*/
        e.target.classList.add('focus:bg-gray-800')

        setSelectedMenu(menu)

        setItems([])
        setOrderSummary([])

        getMenuItems(menu)

    }

    const getMenuItems = menu =>
        axios.get(`api/menu/${selectedMenu}`)
            .then(res => {
                setData(res.data.items)
            })

    const total = items.reduce(
        (acc, cur) => acc + parseFloat(cur.cost) * cur.quantity,
        0
    );

    useEffect(() => {

        getMenuItems()
    }, [selectedMenu])

    return (
        <>

            <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">

                <form>

                    <div
                        className="container pt-8">

                        <div className="flex justify-start items-center">
                            <button
                                onClick={() => addCustomer()}
                                className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" type="button">
                                Add Customer
                            </button>
                        </div>
                    </div>

                </form>

                {
                    customers?.sort().map(c => {
                        return (
                            <>


                                <form
                                    key={`customer-${c.id}`}
                                    className="pb-14"
                                >

                                    <div
                                        className="container">

                                        <div className="pb-8">

                                            <h1 className="text-3xl text-gray-700 font-bold mb-8 capitalize text-center">Select Menu</h1>

                                            <div className="grid grid-cols-3 gap-4 justify-center items-center mt-4">
                                                <label
                                                    className="btn-menus inline-flex items-center bg-gray-200 hover:bg-gray-300 text-white font-bold py-2 px-4 rounded capitalize ">
                                                    <input
                                                        onClick={(e) => toggleButtonMenu(e, "standard")}
                                                        type="radio"
                                                        name="check-menu"
                                                        className="form-checkbox h-5 w-5 text-gray-600"
                                                        defaultChecked
                                                    />
                                                    <span className="ml-2 text-gray-700 font-medium">Standard</span>
                                                </label>

                                                <label
                                                    className="btn-menus inline-flex items-center bg-gray-200 hover:bg-gray-300 text-white font-bold py-2 px-4 rounded capitalize">
                                                    <input
                                                        onClick={(e) => toggleButtonMenu(e, "weekend")}
                                                        type="radio"
                                                        name="check-menu"
                                                        className="form-checkbox h-5 w-5 text-gray-600"
                                                    />
                                                    <span className="ml-2 text-gray-700 font-medium">Weekend</span>
                                                </label>

                                                <label
                                                    className="btn-menus inline-flex items-center bg-gray-200 hover:bg-gray-300 text-white font-bold py-2 px-4 rounded capitalize">
                                                    <input
                                                        onClick={(e) => toggleButtonMenu(e, "catering")}
                                                        type="radio"
                                                        name="check-menu"
                                                        className="form-checkbox h-5 w-5 text-gray-600"
                                                    />
                                                    <span className="ml-2 text-gray-700 font-medium">Catering</span>
                                                </label>

                                            </div>
                                        </div>

                                        <div className="">

                                            <div className="grid grid-cols-10 gap-4">
                                                <div className="col-span-3">
                                                    <div className="shadow-lg bg-white p-6">
                                                        <h3>Customer #{c.id}</h3>
                                                        <div className="mb-4">
                                                            <label className="block text-gray-700 font-bold mb-2" htmlFor="item-select">
                                                                Select Customer Type:
                                                            </label>
                                                            <div className="relative">
                                                                <select
                                                                    id={`ct-${c.id}`}

                                                                    onChange={(e) => setCustomerType(e.target.value)}
                                                                    value={customerType}
                                                                    className="block appearance-none w-full bg-gray-200 border border-gray-200 text-gray-700 py-2 px-4 pr-8 rounded leading-tight focus:outline-none focus:bg-white focus:border-gray-500" id="item-select">
                                                                    <option>Select</option>
                                                                    {
                                                                        customerList?.map(item => {

                                                                            return (
                                                                                <option value={item} key={item}>{item}</option>
                                                                            )

                                                                        })
                                                                    }
                                                                </select>

                                                                <div className="pointer-events-none absolute inset-y-0 right-0 flex items-center px-2 text-gray-700">
                                                                    <svg className="fill-current h-4 w-4" viewBox="0 0 20 20"><path d="M9 11a1 1 0 0 1-2 0V9a1 1 0 0 1 2 0v2zm4 0a1 1 0 0 1-2 0V9a1 1 0 0 1 2 0v2z" /><path fill-rule="evenodd" d="M3 4a1 1 0 0 1 1-1h12a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V4zm2 2v8h8V6H5zm2-2h4v4H7V4z" /></svg>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div className="mb-4">
                                                            <label className="block text-gray-700 font-bold mb-2" htmlFor="item-select">
                                                                Select Item:
                                                            </label>
                                                            <div className="relative">
                                                                <select
                                                                    onChange={handleItemChange}
                                                                    id={`item-${c.id}`}
                                                                    value={itemId}
                                                                    className="block appearance-none w-full bg-gray-200 border border-gray-200 text-gray-700 py-2 px-4 pr-8 rounded leading-tight focus:outline-none focus:bg-white focus:border-gray-500" id="item-select">
                                                                    <option>Select an item</option>
                                                                    {
                                                                        data?.map(item => {

                                                                            return (
                                                                                <option value={item.id} key={c.id + item.id}>{item.name} - {`$${item.cost}`}</option>
                                                                            )

                                                                        })
                                                                    }
                                                                </select>

                                                                <div className="pointer-events-none absolute inset-y-0 right-0 flex items-center px-2 text-gray-700">
                                                                    <svg className="fill-current h-4 w-4" viewBox="0 0 20 20"><path d="M9 11a1 1 0 0 1-2 0V9a1 1 0 0 1 2 0v2zm4 0a1 1 0 0 1-2 0V9a1 1 0 0 1 2 0v2z" /><path fill-rule="evenodd" d="M3 4a1 1 0 0 1 1-1h12a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V4zm2 2v8h8V6H5zm2-2h4v4H7V4z" /></svg>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div className="mb-4">
                                                            <label className="block text-gray-700 font-bold mb-2" htmlFor="quantity-input">
                                                                Quantity:
                                                            </label>
                                                            <input
                                                                type="number"
                                                                onChange={handleQuantityChange}
                                                                value={Number(quantity)}
                                                                defaultValue={quantity}
                                                                id={`quantity-${c.id}`}
                                                                className="appearance-none w-full bg-gray-200 border border-gray-200 text-gray-700 py-2 px-4 pr-8 rounded leading-tight focus:outline-none focus:bg-white focus:border-gray-500" id="quantity-input" type="number" placeholder="Enter quantity"
                                                            />

                                                        </div>
                                                        <div className="flex items-right justify-end">
                                                            <button
                                                                onClick={() => addToOrder()}
                                                                className="bg-blue-500 w-full hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" type="button">
                                                                Add Item
                                                            </button>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div className="bg-white p-6 shadow-lg col-span-7 px-12">

                                                    <div className="bg-white rounded-lg overflow-hidden">
                                                        <div className="p-4">
                                                            <h3 className="text-lg font-semibold text-gray-800 underline">Order Summary</h3>
                                                            <div className="my-4">
                                                                Customer Type: <b className="capitalize text-gray-600">{customerType}</b>
                                                            </div>
                                                            <hr />
                                                            <div className="my-4">
                                                                <div className="flex justify-between">
                                                                    <span className="font-semibold text-gray-600">Item Name</span>
                                                                    <span className="font-semibold text-gray-600">Item Price</span>
                                                                </div>
                                                                {items.map((item) => (
                                                                    <div
                                                                        key={item.id}
                                                                        className="flex justify-between mt-4">
                                                                        <span style={{ width: "80%" }}>{item.name}
                                                                            <p className="text-gray-500 py-2">{item.description}</p>
                                                                            <p className="text-gray-500 ">Quantity: {item.quantity}</p>
                                                                        </span>
                                                                        <span>${item.cost}</span>
                                                                    </div>
                                                                ))}
                                                            </div>

                                                            <div className="flex justify-end mb-4">
                                                                <div className="text-right">
                                                                    <p>
                                                                        <span className="font-semibold text-gray-600">Total: </span>
                                                                        <span>${total.toFixed(2)}</span>
                                                                    </p>
                                                                </div>
                                                            </div>

                                                            <hr />

                                                        </div>

                                                        {
                                                            items.length > 0
                                                                ?
                                                                <>

                                                                    <div className="flex justify-end mt-4">
                                                                        <div className="text-left">
                                                                            <p>
                                                                                <span className="text-gray-600">Original Cost: </span>
                                                                                <span>${orderSummary.originalCost}</span>
                                                                            </p>
                                                                            <p>
                                                                                <span className="text-gray-600">Total Discount: </span>
                                                                                <span>${orderSummary.discountAmount}</span>
                                                                            </p>
                                                                            <p>
                                                                                <span className="text-gray-600">Surcharge: </span>
                                                                                <span>${orderSummary.surcharge}</span>
                                                                            </p>
                                                                            <p>
                                                                                <span className="text-gray-600">Total Cost: </span>
                                                                                <span>${orderSummary.totalCost}</span>
                                                                            </p>
                                                                        </div>
                                                                    </div>

                                                                    <div className="py-5 flex justify-end items-center">
                                                                        <button
                                                                            onClick={() => placeOrder()}
                                                                            className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" type="button">
                                                                            Place Order
                                                                        </button>
                                                                    </div>

                                                                </>
                                                                : ''
                                                        }


                                                    </div>

                                                </div>
                                            </div>


                                        </div>

                                    </div>

                                </form>
                            </>
                        )
                    })
                }

            </div>
        </>
    )

}

export default Order