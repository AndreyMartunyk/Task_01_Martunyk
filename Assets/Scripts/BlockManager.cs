using System;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField]            //just for test
    private BlockScr[] _blocks;
    private int _countOfBlocks;

    public int CountOfBlocks {
        get {
            return _countOfBlocks;
        }
    }

    void Start()
    {
        GameManager.getInstance().SetBlocksManager(this);
        _blocks = gameObject.GetComponentsInChildren<BlockScr>();
        _countOfBlocks = _blocks.Length;
        SetBlocksManager(_blocks);
    }

    public void KillBlock(BlockScr block) {
        --_countOfBlocks;
        Destroy(block.gameObject);
        if (_countOfBlocks <= 0) {
            WinGame();
        }
    }

    private void WinGame() {
        GameManager.getInstance().WinGame();
    }

    private void SetBlocksManager(BlockScr[] blocks) {
        for (int i = 0; i < blocks.Length; i++) {
            blocks[i].SetBlockManager(this);
        }
    }


}
