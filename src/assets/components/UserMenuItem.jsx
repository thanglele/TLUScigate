import React, { useState } from "react";
import Button from "./Button";

const UserMenuItem = () => {
  const [isDropdownOpen, setIsDropdownOpen] = useState(false);

  const toggleDropdown = () => {
    setIsDropdownOpen(!isDropdownOpen);
  };

  return (
    <div className="relative">
      {/* Phần click để mở dropdown */}
      <div
        className="p-4 border-t border-gray-200 flex items-center cursor-pointer"
        onClick={toggleDropdown}
      >
        <img
          src="https://i.pravatar.cc/40"
          alt="User Avatar"
          className="w-10 h-10 rounded-full mr-3"
        />
        <div className="flex-1">
          <p className="text-sm font-medium">Nguyễn Quang Hiếu <span className="text-gray-500">{isDropdownOpen ? "▲" : "▼"}</span> </p>
          <p className="text-xs text-gray-500">Ban Quản lý</p>
        </div>
        {/* Icon mũi tên (dùng emoji hoặc icon library) */}
      </div>

      {/* Dropdown content */}
      {isDropdownOpen && (
        <div className="absolute right-0 bottom-full mb-2 w-48 bg-white border border-gray-200 rounded-md shadow-lg z-10">
          <Button value={"Đăng xuất"} textSize={"text-sm"} color={"bg-red-500"} />
        </div>
      )}
    </div>
  );
};

export default UserMenuItem;