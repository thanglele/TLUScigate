
const UdateMagazine = () => {
    const RequiredLabel = ({ children }: { children: string }) => (
        <span className="text-sm font-medium text-gray-700 dark:text-gray-200">
            {children} <span className="text-red-500">*</span>
        </span>
    );

    return (
        <div className="p-6 bg-white rounded-lg shadow-sm dark:bg-gray-800">
            <h1 className="text-2xl font-bold mb-6 text-gray-800 dark:text-white">
                Đăng kí ấn phẩm
            </h1>
            <div className="pb-4">
                <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
                    <div>
                        <RequiredLabel>Mã ấn phẩm</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Nhập mã ấn phẩm"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Tên ấn phẩm</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mtt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Nhập tên ấn phẩm"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Loại ấn phẩm</RequiredLabel>
                        <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
                            <option>Tạp chí</option>
                            <option>Báo cáo</option>
                        </select>
                    </div>
                    <div>
                        <RequiredLabel>Năm xuất bản</RequiredLabel>
                        <input
                            type="date"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Nhập năm xuất bản"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Nhà xuất bản</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Nhập nhà xuất bản"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Trạng thái</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn trạng thái"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Quốc gia</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Nhập quốc gia"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngôn ngữ</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Nhập ngôn ngữ"
                        />
                    </div>
                    <div>
                        <RequiredLabel>ISSN_ISBN</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Nhập ISSN_ISBN"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Tên tác giả</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Nhập tên tác giả"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Email</RequiredLabel>
                        <input
                            type="email"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Nhập email giảng viên"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Học hàm</RequiredLabel>
                        <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
                            <option>PGS</option>
                        </select>
                    </div>
                    <div>
                        <RequiredLabel>Học vị</RequiredLabel>
                        <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
                            <option>TS</option>
                        </select>
                    </div>
                    <div>
                        <RequiredLabel>Chức vụ</RequiredLabel>
                        <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
                            <option>Trưởng Khoa</option>
                            <option>Giảng viên</option>
                        </select>
                    </div>

                    <div>
                        <RequiredLabel>Học vị</RequiredLabel>
                        <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
                            <option>Chọn học vị</option>
                            <option>Thạc sĩ</option>
                            <option>Tiến sĩ</option>
                        </select>
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
                        Cập nhật
                    </button>
                </div>
            </div>
        </div>
    );
};

export default UdateMagazine;