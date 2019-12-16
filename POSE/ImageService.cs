using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSE
{
    // TODO: Implementiats den WCF scheißdreck
    // Mit dea file haubts oba vmtl. nix augfaungt, weilses WCF Projekt importian measats
    public interface ImageService
    {
        List<MyImage> getImageList();
        byte[] getImage(string name);
    }
}
