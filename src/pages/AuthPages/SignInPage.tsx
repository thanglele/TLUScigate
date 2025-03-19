import React, { useState } from 'react';
import Logo from '/images/logo/logo-tlu.svg'; 

const LoginPage: React.FC = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [isLoading, setIsLoading] = useState(false);
    const [borderValid, setBorderValid] = useState(false);

    const handleLogin = (e: React.FormEvent) => {
        e.preventDefault();
     
        setIsLoading(true);
        console.log({ email, password });
        
        setTimeout(() => {
            setIsLoading(false);
        }, 2000);
    };

    const handleKeyDown = (e: React.KeyboardEvent) => {
        // Xử lý sự kiện bàn phím nếu cần
    };

    return (
        <div className="min-h-screen custom-gradient flex justify-center items-center bg-[#030a29]">
            <div className="flex flex-col md:flex-row justify-between w-full max-w-6xl px-5 md:gap-60 m-2">
                <div className="text-white md:w-2/5 mb-8 md:mb-2 md:px-2 ml-30 md:ml-0">
                    <h1 className="font-extrabold text-4xl md:text-5xl italic leading-tight">
                        Welcome to <br /> TLU SciGate.
                    </h1>
                    <p className="mt-4 text-lg md:text-xl italic">
                        Cross this gateway to
                        <br />
                        explore the infinite sky of science!
                    </p>
                </div>

                <form onSubmit={handleLogin} className="w-full md:w-1/2 bg-white p-8 rounded-lg shadow-lg">
                   <div className="card-header flex items-center justify-between">
                        <h2 className="text-3xl font-bold text-center mb-8">ĐĂNG NHẬP</h2>
                        <img src={Logo} alt="TLU" className="h-20 w-auto" />
                   </div>
                    
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-medium mb-2">
                            Tài khoản
                        </label>
                        <input
                            type="email"
                            placeholder="Nhập email"
                            className={`w-full px-4 py-2 border rounded-lg focus:outline-none ${
                                borderValid ? 'border-red-500' : 'border-gray-300'
                            }`}
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            onKeyDown={handleKeyDown}
                        />
                    </div>

                    <div className="mb-6">
                        <label className="block text-gray-700 text-sm font-medium mb-2">
                            Mật khẩu
                        </label>
                        <input
                            type="password"
                            placeholder="Nhập mật khẩu"
                            className="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            onKeyDown={handleKeyDown}
                        />
                    </div>

                    <button
                        type="submit"
                        disabled={isLoading}
                        className={`w-full py-2 px-4 rounded-lg text-white font-medium ${
                            isLoading 
                            ? 'bg-gray-400 cursor-not-allowed' 
                            : 'bg-blue-600 hover:bg-blue-700'
                        }`}
                    >
                        {isLoading ? 'Đang xử lý...' : 'Đăng nhập'}
                    </button>

                    <a href="#" className="block text-right mt-4 text-sm text-blue-600 hover:text-blue-800">
                        Quên mật khẩu?
                    </a>
                </form>
            </div>
        </div>
    );
};

export default LoginPage;