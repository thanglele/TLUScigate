
const AddScience = () => {
    const RequiredLabel = ({ children }: { children: string }) => (
        <span className="text-sm font-medium text-gray-700 dark:text-gray-200">
            {children} <span className="text-red-500">*</span>
        </span>
    );

    return (
        <div className="p-6 bg-white rounded-lg shadow-sm dark:bg-gray-800">
            <h1 className="text-2xl font-bold mb-6 text-gray-800 dark:text-white">
                Đăng ký bài công bố khoa học
            </h1>
            <div className="pb-4">
                <span className="text-2xl font-bold mb-6 text-gray-800 dark:text-white">
                    1. Thông tin bài công bố
                </span>
                <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                    <div>
                        <RequiredLabel>Mã công bố:</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                    
                </div>
                <div className="grid grid-cols-1 md:grid-cols-1 gap-4">
                <div>
                        <RequiredLabel>Tóm tắt</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Hà Nội"
                        />
                    </div>

                </div>
                <div className="grid grid-cols-1 md:grid-cols-3 gap-4 pt-2">
                    <div>
                        <RequiredLabel>Học vị</RequiredLabel>
                        <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
                            <option>Chọn học vị</option>
                            <option>Thạc sĩ</option>
                            <option>Tiến sĩ</option>
                        </select>
                    </div>
                    <div>
                        <RequiredLabel>Ngày vào</RequiredLabel>
                        <input
                            type="date"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Nhập mã giảng viên"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Nhập mật khẩu</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Nhâp mật khẩu"
                        />
                    </div>
                </div>
                <div className="grid grid-cols-1 md:grid-cols-1 gap-4 pt-2">
                    <div>
                        <RequiredLabel>Ghi chú</RequiredLabel>
                        <textarea
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Ghi chú thêm..."
                        />
                    </div>
                </div>
            </div>
            <div className="space-y-6">

                {/* Nút hành động */}
                <div className="flex justify-end gap-3 pt-6">
                    <button className="px-6 py-2 text-gray-700 bg-gray-100 rounded-lg hover:bg-gray-200 dark:bg-gray-600 dark:text-gray-200"
                    // onClick={onClose}
                    >
                        Hủy
                    </button>
                    <button className="px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 dark:bg-blue-700 dark:hover:bg-blue-800">
                        Đăng Ký
                    </button>
                </div>
            </div>
        </div>
    );
};

export default AddScience;