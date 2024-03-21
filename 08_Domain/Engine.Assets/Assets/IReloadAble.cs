namespace Engine.Assets.Assets;

public interface IReloadAble : IDisposable
{
    void TryReload(object asset);
}

public interface IReloadAble<in T> : IReloadAble
    where T : IAsset
{
    void TryReload(T asset);

    void IReloadAble.TryReload(object asset) => TryReload((T)asset);
}
