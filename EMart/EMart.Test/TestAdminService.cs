using System;
using System.Collections.Generic;
using System.Text;
using EMart.AdminService.Models;
using EMart.AdminService.Repositories;
using NUnit.Framework;


namespace EMart.Test
{
    [TestFixture]
    class TestAdminService
    {
        AdminRepository _repo;
        [SetUp]
        public void SetUp()
        {
            _repo = new AdminRepository(new EMartDBContext());

        }
        [Test]
        [Description("AddCategory()")]
        public void TestAddCategory()
        {
            _repo.AddCategory(new Category()
            {
                CategoryId = "C0010",
                CategoryName="Homeappliances",
                BriefDetails=""

            }) ;
            var result = _repo.GetCatById("C0010");
            Assert.NotNull(result);
            
            
        }
        [Test]
        [Description("AddSubCategory()")]
        public void TestAddSubCategory()
        {
            _repo.AddSubCategory(new SubCategory()
            {
                SubcategoryId="SC008",
                SubcategoryName="Furnitur",
                CategoryId="C0010",
                BriefDetails="Best Quality",
                Gst="18"
            }
                );
            var result = _repo.GetSubcatById("SC008");
            Assert.NotNull(result);
        }
        [Test]
        [Description("UpdateCategory()")]
        public void TestUpdateCategory()
        {
            Category category = _repo.GetCatById("C0010");
            category.BriefDetails = "Good quality";
            _repo.UpdateCategory(category);
            Category category1 = _repo.GetCatById("C0010");
            Assert.AreEqual(category1, category);

        }
        [Test]
        [Description("UpdateSubcategory()")]
        public void TestUpdateSubcategory()
        {
            SubCategory subcategory = _repo.GetSubcatById("SC008");
            subcategory.BriefDetails = "Good quality";
            _repo.UpdateSubcategory(subcategory);
            SubCategory subcategory1 = _repo.GetSubcatById("SC008");
            Assert.AreEqual(subcategory1, subcategory);

        }
        [Test]
        [Description("DeleteCategory()")]
        public void TestDeleteCategory()
        {
            _repo.DeleteCategory("C0010");
            var result = _repo.GetCatById("C0010");
            Assert.Null(result);
        }
        [Test]
        [Description("DeleteSubcategory()")]
        public void TestDeleteSubcategory()
        {
            _repo.DeleteSubCategory("SC008");
            var result = _repo.GetSubcatById("SC008");
            Assert.Null(result);
        }
       
    }

}
