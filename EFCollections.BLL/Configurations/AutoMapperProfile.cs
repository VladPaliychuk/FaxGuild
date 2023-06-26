using AutoMapper;
using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.DAL.Entities;

namespace EFCollections.BLL.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateUserMaps();
            CreateIdentityMap();
            CreateCollectionMaps();
            CreatePostMaps();
            CreateStorageMaps();
            CreateSavedMaps();
            CreateCollectionPostMaps();
        }
        /*private void CreateUserMaps()
        {
            CreateMap<SignInRequest, User>();
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();
        }   */
        private void CreateIdentityMap()
        {
            CreateMap<User, SignUpRequest>().ReverseMap();
        }
        private void CreateCollectionMaps()
        {
            CreateMap<CollectionRequest, Collection>();
            CreateMap<Collection, CollectionResponse>();
        }
        private void CreateCollectionPostMaps()
        {
            CreateMap<CollectionPostRequest, CollectionPost>();
            CreateMap<CollectionPost, CollectionPostResponse>();
        }
        private void CreatePostMaps()
        {
            CreateMap<PostRequest, Post>();
            CreateMap<Post, PostResponse>();
        }
        private void CreateSavedMaps()
        {
            CreateMap<SavedRequest, Saved>();
            CreateMap<Saved, SavedResponse>();
        }
        private void CreateStorageMaps()
        {
            CreateMap<StorageRequest, Storage>();
            CreateMap<Storage, StorageResponse>();
        }
    }
}
