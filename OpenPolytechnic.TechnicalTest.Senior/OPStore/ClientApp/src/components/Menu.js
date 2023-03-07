import { useEffect, useState } from 'react'
import axios from 'axios'

const Menu = () => {

    const [data, setData] = useState([])

    const [selectedTab, setSelectedTab] = useState('standard');

    const handleTabClick = (menu) => {     
        
        setSelectedTab(menu)
        getMenuItems();
    };

    const getMenuItems = menu => 
        axios.get(`api/menu/${selectedTab}`)
            .then(res => {
                console.log(res.data.items)
                setData(res.data.items)
            })
   

    useEffect(() => {
        getMenuItems()
    }, [selectedTab])

    return (
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
            <div className="py-4">
                <div className="container mx-auto py-8">

                    <div className="flex border-b border-gray-200">
                        <button
                            className={`text-gray-500 hover:text-gray-700 font-semibold py-2 px-4 border-b-2 border-transparent hover:border-indigo-500 focus:outline-none ${selectedTab === 'standard' && "bg-gray-200"}`}
                            onClick={() => handleTabClick('standard')}
                        >
                            Standard Menu
                        </button>
                        <button
                            className={`text-gray-500 hover:text-gray-700 font-semibold py-2 px-4 border-b-2 border-transparent hover:border-indigo-500 focus:outline-none ${selectedTab === 'weekend' && "bg-gray-200"
                                }`}
                            onClick={() => handleTabClick('weekend')}
                        >
                            Weekend Menu
                        </button>
                        <button
                            className={`text-gray-500 hover:text-gray-700 font-semibold py-2 px-4 border-b-2 border-transparent hover:border-indigo-500 focus:outline-none ${selectedTab === 'catering' && "bg-gray-200"
                                }`}
                            onClick={() => handleTabClick('catering')}
                        >
                            Catering Menu
                        </button>
                    </div>

                </div>

                <div className="container mx-auto py-8">
                    <h1 className="text-3xl text-gray-700 font-bold mb-8 uppercase">{`${selectedTab} Menu`}</h1>
                    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">                       
                        {
                            data.map(item => {

                                return (
                                    <div className="bg-white rounded-lg shadow-lg overflow-hidden" key={`item-${item.id}`}>
                                        {/*<img src="https://via.placeholder.com/500x300" alt="Pizza" className="w-full h-56 object-cover" />*/}
                                        <div className="p-6">
                                            <h2 className="text-xl text-gray-800 font-bold mb-2">{ item.name }</h2>
                                            <p className="text-gray-600 text-base">{ item.description }</p>
                                            <span className="text-gray-700 font-bold text-xl">{`$${item.cost}`}</span>
                                        </div>
                                    </div>
                                )

                            })
                        }

                    </div>
                </div>
            </div>
        </div>
    );
}

export default Menu;
