export default function ViewsStudent() {
    const RequiredLabel = ({ children }: { children: string }) => (
        <span className="text-sm font-medium text-gray-700 dark:text-gray-200">
          {children} <span className="text-red-500">*</span>
        </span>
      );
    return (
        <div className="p-6 bg-white rounded-lg shadow-sm dark:bg-gray-800">
            <h1 className="text-2xl  text-center font-bold mb-6 text-gray-800 dark:text-white">
               ĐỀ TÀI - QUẢN LÝ PHÒNG TRỌ
            </h1>
            <div className="pb-4">
                <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
                    1. Thông tin chung
                </span>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-3 gap-4">
                    <div>
                        <RequiredLabel>Tên đề tài</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                           
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                           
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                         
                        />
                    </div>
                </div>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-4 gap-4">
                    <div>
                        <RequiredLabel>Chủ nhiệm đề tài</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                          
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mã sinh viên</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                           
                        />
                    </div>
                    <div>
                        <RequiredLabel>Tình trạng đề tài</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Lĩnh vự nghiên cứu</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                </div>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-4 gap-4">
                    <div>
                        
                        <RequiredLabel>Tên thành viên 1</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mã sinh viên</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                           
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn khoa"
                        />
                    </div>
                </div>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-4 gap-4">
                    <div>
                        
                        <RequiredLabel>Tên thành viên 2</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mã sinh viên</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                           
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn khoa"
                        />
                    </div>
                </div>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-4 gap-4">
                    <div>
                        
                        <RequiredLabel>Tên thành viên 3</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mã sinh viên</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                           
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn khoa"
                        />
                    </div>
                </div>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-4 gap-4">
                    <div>
                        
                        <RequiredLabel>Tên thành viên 4</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mã sinh viên</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                           
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn khoa"
                        />
                    </div>
                </div>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-4 gap-4">
                    <div>
                        
                        <RequiredLabel>Tên thành viên 5</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mã sinh viên</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                           
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                           
                        />
                    </div>
                </div>
                {/* NGƯỜI HƯỚNG DẪN */}
                <div className="grid pb-5 grid-cols-1 md:grid-cols-5 gap-4">
                    <div>
                        <RequiredLabel>Người hướng dẫn đề tài</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                        
                        />
                    </div>
                    <div>
                        <RequiredLabel>Học vị</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Học hàm</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                           
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                </div>
            </div>
            {/* THỜI GIAN THỰC HIỆN */}
            <div className="pb-4">
                <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
                    2. Thời gian thực hiện
                </span>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-2 gap-4 pt-2">
                    <div>
                        <RequiredLabel>Ngày bắt đầu</RequiredLabel>
                        <input
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngày kết thúc dự kiến</RequiredLabel>
                        <input
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                </div>
            </div>
            {/* THỜI GIAN THỰC HIỆN */}
            <div className="pb-4">
                <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
                    3. Kinh phí và tài trợ
                </span>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-2 gap-4 pt-2">
                    <div>
                        <RequiredLabel>Tổng kinh phí và tài trợ</RequiredLabel>
                        <input
                            type="money"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Nguồn tài trợ</RequiredLabel>
                        <input
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                </div>
            </div>
            <div className="pb-4">
                <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
                    4. Nội dung nghiên cứu
                </span>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-1 gap-4 pt-2">
                    <div>
                        <RequiredLabel>Giới thiệu tổng quan về đề tài</RequiredLabel>
                        <textarea
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            
                        />
                    </div>
                    <div>
                        <RequiredLabel>Tính cấp thiết của đề tài</RequiredLabel>
                        <textarea
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                          
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mục tiêu của đề tài</RequiredLabel>
                        <textarea
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                           
                        />
                    </div>
                    <div>
                        <RequiredLabel>Kết quả, sản phẩm dự kiến</RequiredLabel>
                        <textarea
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                        />
                    </div>
                </div>
            </div>
            <div className="space-y-6">
                <div className="flex justify-end gap-3 pt-6 gap-3">
                    <button className="px-6 py-2 text-gray-700 bg-gray-100 rounded-lg hover:bg-gray-200 dark:bg-gray-600 dark:text-gray-200"
                    >
                        Hủy
                    </button>
                    <button className="px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 dark:bg-blue-700 dark:hover:bg-blue-800"
                    >
                        Cập nhật
                    </button>
                </div>
            </div>
        </div>
        
    )
  }