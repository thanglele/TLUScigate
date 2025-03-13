import React from 'react';
import WelcomeSection from '../organisms/WelcomeSection';
import LoginForm from '../organisms/LoginForm';
import "/Users/leduc/QLKHTLU/src/index.css"

const LoginPage = () => {
  return (
    <div className="min-h-screen custom-gradient flex justify-center items-center">
      <div className="flex flex-col md:flex-row justify-between w-full max-w-6xl px-5 gap-5 md:gap-60 m-2">
        <WelcomeSection />
        <LoginForm />
      </div>
    </div>
  );
};

export default LoginPage;