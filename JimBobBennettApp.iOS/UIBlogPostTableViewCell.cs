using System;
using JimBobBennettApp.Portable;
using UIKit;

namespace JimBobBennettApp.iOS
{
	partial class UIBlogPostTableViewCell : UITableViewCell
	{
	    private FeedItem _blogPost;

	    public UIBlogPostTableViewCell(IntPtr handle) : base(handle)
	    {
	    }

	    public UIBlogPostTableViewCell()
            : base(UITableViewCellStyle.Default, "BlogPostCell")
	    {
	    }

	    public FeedItem BlogPost
	    {
	        get { return _blogPost; }
	        set
	        {
	            _blogPost = value;
	            Title.Text = _blogPost.Title;
	            Categories.Text = _blogPost.Categories;
                TagIcon.Font = UIFont.FromName("fontawesome", 14f);
	            TagIcon.Text = '\uf040'.ToString();
	        }
	    }
	}
}
